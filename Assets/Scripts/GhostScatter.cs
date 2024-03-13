using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            int index = Random.Range(0, node.availebleDirections.Count);

            if (node.availebleDirections[index] == -this.ghost.movement.direction && node.availebleDirections.Count > 1)
            {
                index++;

                if (index >= node.availebleDirections.Count) {
                    index = 0;
                } 
            }

            this.ghost.movement.SetDirection(node.availebleDirections[index]);
        }
    }
}
